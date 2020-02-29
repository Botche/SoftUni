class Forum {
    constructor() {
        this._users = [];
        this._questions  = [];
        this._id = 1;
    }

    register(username, password, confirmPassword, email) {
        if (username === ''
            || password === ''
            || confirmPassword === ''
            || email === '') {
            throw new Error('Input can not be empty');
        }

        if (password !== confirmPassword) {
            throw new Error('Passwords do not match');
        }

        if (this._users.find(user => user.username === username || user.email === email)) {
            throw new Error('This user already exists!');
        }

        this._users.push({
            username: username,
            email: email,
            password: password,
            isLogged: false
        })

        return `${username} with ${email} was registered successfully!`;
    }

    login(username, password) {
        let user = this._users.find(user => user.username === username)
        if (!user) {
            throw new Error('There is no such user');
        }

        if (user.password === password && user.isLogged === false) {
            user.isLogged = true;
            return 'Hello! You have logged in successfully';
        }
    }

    logout(username, password){
        let user = this._users.find(user => user.username === username)
        if (!user) {
            throw new Error('There is no such user');
        }

        if (user.password === password && user.isLogged === true) {
            user.isLogged = true;
            return 'You have logged out successfully';
        }
    }

    postQuestion(username, question){
        let user = this._users.find(user => user.username === username)
        if (!user || !user.isLogged) {
            throw new Error('You should be logged in to post questions');
        }

        if(question === ''){
            throw new Error('Invalid question');
        }

        this._questions.push({
            id: this._id++,
            username: username,
            question: question,
            answers: []
        });

        return 'Your question has been posted successfully';
    }

    postAnswer(username, questionid, answer){
        let user = this._users.find(user => user.username === username)
        if (!user || !user.isLogged) {
            throw new Error('You should be logged in to post answers');
        }

        if(answer === ''){
            throw new Error('Invalid answer');
        }

        let question = this._questions.find(question=>question.id === questionid);

        if(!question){
            throw new Error('There is no such question');
        }

        question.answers.push({
            username: username,
            answer: answer
        });

        return 'Your answer has been posted successfully';
    }

    showQuestions(){
        let output = [];
        for (const question of this._questions) {
            output.push(`Question ${question.id} by ${question.username}: ${question.question}`);
            for (const answer of question.answers) {
                output.push(`---${answer.username}: ${answer.answer}`);
            }
        }

        return output.join('\n');
    }
}



let forum = new Forum();

console.log(forum.register('Jonny', '12345', '12345', 'jonny@abv.bg'));
console.log(forum.register('Peter', '123ab7', '123ab7', 'peter@gmail@.com'));
console.log(forum.login('Jonny', '12345'));
console.log(forum.login('Peter', '123ab7'));


console.log(forum.postQuestion('Jonny', "Do I need glasses for skiing?"));
console.log(forum.postAnswer('Peter',1, "Yes, I have rented one last year."));
console.log(forum.postAnswer('Jonny',1, "What was your budget"));
console.log(forum.postAnswer('Peter',1, "$50"));
console.log(forum.postAnswer('Jonny',1, "Thank you :)"));

console.log(forum.showQuestions());
