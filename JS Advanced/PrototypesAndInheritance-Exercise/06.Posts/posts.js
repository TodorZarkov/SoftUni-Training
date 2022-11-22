function solution() {

    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`
        }
    }


    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = likes;
            this.dislikes = dislikes;

            this._comments = [];
        }

        addComment(comment) {
            this._comments.push(comment);
        }

        toString() {
            let result = super.toString() + "\n";
            result += `Rating: ${this.likes - this.dislikes}`;
            
            if(this._comments.length === 0) return result;

            result += `\nComments:\n`;
            result += this._comments.map(c=>` * ${c}`).join("\n");
            return result;
        }
    }


    class BlogPost extends Post{
        constructor(title, content, views){
            super(title, content);
            this._views = views;
        }

        view() {
            this._views++
            return this;
        }

        toString() {
            let result = super.toString() + "\n";
            
            result += `Views: ${this._views}`

            return result;
        }

    }


    return {Post, SocialMediaPost, BlogPost };

}


const classes = solution();
let post = new classes.Post("Post", "Content");

console.log(post.toString());

// Post: Post
// Content: Content

let scm = new classes.SocialMediaPost("TestTitle", "TestContent", 25, 30);

scm.addComment("Good post");
scm.addComment("Very good post");
scm.addComment("Wow!");

console.log(scm.toString());

// Post: TestTitle
// Content: TestContent
// Rating: -5
// Comments:
//  * Good post
//  * Very good post
//  * Wow!