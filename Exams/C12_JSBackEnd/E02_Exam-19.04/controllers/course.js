const env = process.env.NODE_ENV || 'development';

const jwt = require('jsonwebtoken');
const config = require('../config/config')[env];
const Course = require('../models/course');
const User = require('../models/user');

const saveCourse = async (req, res) => {
    const {
        title,
        description,
        imageUrl,
        isPublic,
    } = req.body;
    
    try {
        const token = req.cookies['aid'];
        const decodedObject = jwt.verify(token, config.privateKey);

        const date = new Date();
        const course = new Course({
            title,
            description,
            imageUrl,
            isPublic: isPublic === 'on' ? true : false,
            createdAt: date.getUTCDate(),
            creatorId: decodedObject.userId
        });

        await course.save();

        return course;
    } catch (error) {
        return {
            error: error,
        }
    }
};

const getAllCourses = async () => {
    const courses = await Course.find().lean();

    const sorted = courses.sort((a, b) => b.title - a.title); 

    return sorted;
}

const getCourse = async (courseId) => {
    const courses = await Course.findById(courseId).lean();

    return courses;
}

const enrollInCourse = async (userId, courseId) => {
    try {
        await Course.findByIdAndUpdate(courseId, {
            $addToSet: {
                usersEnrolled: [userId]
            }
        });
    
        await User.findByIdAndUpdate(userId, {
            $addToSet: {
                enrolledCourses: [courseId]
            }
        });

        return true;
    } catch (error) {
        return {
            error
        }
    }
}

const checkIfUserIsInCourse = async (userId, courseId) => {
    const user // TODO;
}

module.exports = {
    saveCourse,
    getAllCourses,
    getCourse,
    enrollInCourse
}