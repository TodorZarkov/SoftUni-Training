'use strict';
function squareOfStars(numberOfStars = 5) {
    let stars = "* ".repeat(numberOfStars);
    let print = "";
    for (let i = 0; i < numberOfStars; i++) {
        //stars += `\n`;
        print +=stars + '\n';
    }
    console.log(print);
}
squareOfStars(3);