'use strict';
function generateRectangle(width, height, color=""){
    let rectangle = {
        width,
        height,
        color,
        calcArea: function(){
            return this.width * this.height;
        }
    }
    rectangle.color = rectangle.color[0].toUpperCase() + rectangle.color.slice(1);
    // console.log(rectangle.color);
    // console.log(rectangle.calcArea());
    return rectangle;
}

generateRectangle(4, 5, 'red');