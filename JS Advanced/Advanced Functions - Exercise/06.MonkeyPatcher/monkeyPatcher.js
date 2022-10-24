let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};


function patcher(command) {
    if (command === 'upvote') {
        this.upvotes++;
    }
    else if (command === 'downvote') {
        this.downvotes++
    }
    else if ('score') {
        let mockUpvotes = this.upvotes;
        let mockDownvotes = this.downvotes;
        if (this.upvotes + this.downvotes > 50) {
            let toAdd = this.upvotes > this.downvotes ? Math.ceil(this.upvotes * 0.25) : Math.ceil(this.downvotes * 0.25);
            mockUpvotes += toAdd;
            mockDownvotes += toAdd;
        }
        let balance = mockUpvotes - mockDownvotes;

        let totalVotes = this.upvotes + this.downvotes;
        let rating = 'new';
        if (this.upvotes / totalVotes > 0.66) {
            rating = 'hot';
        }
        else if (this.upvotes / totalVotes <= 0.66 && balance >= 0 && totalVotes > 100) {
            rating = 'controversial';
        }
        else if (balance < 0) {
            rating = 'unpopular';
        }

        if (rating === 'new' || totalVotes < 10) {
            rating = 'new';
        }

        return [mockUpvotes, mockDownvotes, balance, rating];
    }
};


patcher.call(post, 'upvote');
patcher.call(post, 'downvote');
let score = patcher.call(post, 'score'); // [127, 127, 0, 'controversial']
console.log(score);

for (let i = 0; i < 50; i++)
    patcher.call(post, 'downvote');   // (executed 50 times)


score = patcher.call(post, 'score');
console.log(score);