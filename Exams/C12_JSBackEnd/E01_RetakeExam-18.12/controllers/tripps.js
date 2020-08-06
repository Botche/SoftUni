const Tripp = require('../models/tripp');

const getAllTripps = async () => {
    const allTrips = await Tripp.find().lean();

    return allTrips;
}

const getTripp = async (id) => {
    const tripp = await Tripp.findById(id).lean();

    return tripp;
}

const getEmailsOfJoinedBuddiesByTrippId = async (trippId) => {
    const populatedBuddies = await Tripp.findById(trippId).populate('buddies').lean();

    return populatedBuddies.buddies.map(buddy => buddy.email).join(', ');
}

const caclulateFreeSeatsForTripp = (tripp) => {
    const areThereFreeSeats = tripp.buddies.length < tripp.seats;
    const freeSeats = tripp.seats - tripp.buddies.length;

    return {
        areThereFreeSeats,
        freeSeats,
    }
}

const getCreatorEmail = async (trippId) => {
    const populatedCreator = await Tripp.findById(trippId).populate('creatorId').lean();

    return populatedCreator.creatorId.email;
}

const deleteTripp = async (trippId) => {
    await Tripp.findByIdAndDelete(trippId);
}

const joinTripp = async (trippId, userId) => {
    await Tripp.findByIdAndUpdate(trippId, {
        $addToSet: {
            buddies: [userId],
        },
    })
}

module.exports = {
    getAllTripps,
    getTripp,
    getEmailsOfJoinedBuddiesByTrippId,
    caclulateFreeSeatsForTripp,
    getCreatorEmail,
    deleteTripp,
    joinTripp
}