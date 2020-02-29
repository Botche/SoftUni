class Article {
    idForComment = 1;
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {
        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`;
        }
        if (this._likes.length === 1) {
            return `${this._likes[0]} likes this article!`;
        }

        return `${this._likes[0]} and ${this._likes.length - 1} others like this article!`;
    }

    like(username) {
        let user = this._likes.find(like => like === username);

        if (user) {
            throw new `You can't like the same article twice!`;
        }

        if (this.creator === username) {
            throw new `You can't like your own articles!`;
        }

        this._likes.push(username);

        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        let user = this._likes.find(like => like === username);

        if (!user) {
            throw new `You can't dislike this article!`;
        }

        this._likes = this._likes.filter(like => like !== user);

        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        let idFromComments = this._comments.find(comment => comment.Id === id);

        if (!id || !idFromComments) {
            this._comments.push({
                Id: this.idForComment++,
                Username: username,
                Content: content,
                Replies: []
            });

            return `${username} commented on ${this.title}`;
        }


        let comment = this._comments.find(comment => comment.Id === id);
        let currentReplieId = comment.Replies.length + 1;
        comment.Replies.push({
            Id: `${id}.${currentReplieId}`,
            Username: username,
            Content: content
        });

        return 'You replied successfully';
    }

    toString(sortingType) {
        let sortedComments = [];
        if (sortingType === 'asc') {
            sortedComments = this._comments.sort((a, b) => a.Id - b.Id)
            sortedComments.forEach(comment => comment.Replies.sort((a, b) => a.Id - b.Id));
        }
        else if (sortingType === 'desc') {
            sortedComments = this._comments.sort((a, b) => b.Id - a.Id)
            sortedComments.forEach(comment => comment.Replies.sort((a, b) => b.Id - a.Id));
        }
        else if (sortingType === 'username') {
            sortedComments = this._comments.sort((a, b) => a.Username.localeCompare(b.Username))
            sortedComments.forEach(comment => comment.Replies.sort((a, b) => a.Username.localeCompare(b.Username)));
        }

        let result = [];
        result.push(`Title: ${this.title}`);
        result.push(`Creator: ${this.creator}`);
        result.push(`Likes: ${this._likes.length}`);
        result.push('Comments:');

        sortedComments.forEach(el => {
            result.push(`-- ${el.Id}. ${el.Username}: ${el.Content}`);
            el.Replies.forEach(replie => {

                result.push(`--- ${replie.Id}. ${replie.Username}: ${replie.Content}`);
            })
        })

        return result.join('\n');
    }
}

let art = new Article("My Article", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));

