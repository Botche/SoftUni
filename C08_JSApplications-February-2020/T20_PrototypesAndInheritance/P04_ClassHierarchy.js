function generateClasses() {
    class Figure {

        constructor(unit) {
            if (new.target === Figure) {
                throw new Error('Abstract class cannot be instantiated');
            }

            this.unit = unit;
            this.unitMultiplier = 1;
        }

        get area() {
        }

        changeUnits(unit) {
            this.unit = unit;
        }

        toString() {
            return `Figures units: ${this.unit} Area: ${this.area} - `;
        }
    }

    class Circle extends Figure {
        constructor(radius, unit = 'cm') {
            super(unit);
            this.radius = radius;
            switch (unit) {
                case 'mm':
                    this.radius *= 10;
                    break;
                case 'm':
                    this.radius /= 100;
                    break;
                default:
                    break;
            }
        }

        get area() {

            return Math.PI * this.radius * this.radius;
        }

        changeUnits(unit) {

            switch (this.unit) {
                case 'cm':
                    switch (unit) {
                        case 'mm':
                            this.radius *= 10;
                            break;
                        case 'm':
                            this.radius /= 100;
                            break;
                        default:
                            break;
                    }
                    break;
                case 'mm':
                    switch (unit) {
                        case 'm':
                            this.radius /= 1000;
                            break;
                        case 'cm':
                            this.radius /= 10;
                            break;
                        default:
                            break;
                    }
                    break;
                case 'm':
                    switch (unit) {
                        case 'mm':
                            this.radius *= 1000;
                            break;
                        case 'cm':
                            this.radius *= 100;
                            break;
                        default:
                            break;
                    }
                    break;
            }
            this.unit = unit;
        }

        toString() {
            return super.toString() + `radius: ${this.radius}`;
        }
    }

    class Rectangle extends Figure {
        constructor(width, height, unit = 'cm') {
            super(unit);
            this.width = width;
            this.height = height;

            switch (unit) {
                case 'mm':
                    this.width *= 10;
                    this.height *= 10;
                    break;
                case 'm':
                    this.width /= 100;
                    this.height /= 100;
                    break;
                default:
                    break;
            }
        }


        get area() {

            return this.width * this.height;
        }

        changeUnits(unit) {

            switch (this.unit) {
                case 'cm':
                    switch (unit) {
                        case 'mm':
                            this.width *= 10;
                            this.height *= 10;
                            break;
                        case 'm':
                            this.width /= 100;
                            this.height /= 100;
                            break;
                        default:
                            break;
                    }
                    break;
                case 'mm':
                    switch (unit) {
                        case 'm':
                            this.width /= 1000;
                            this.height /= 1000;
                            break;
                        case 'cm':
                            this.width /= 10;
                            this.height /= 10;
                            break;
                        default:
                            break;
                    }
                    break;
                case 'm':
                    switch (unit) {
                        case 'mm':
                            this.width *= 1000;
                            this.height *= 1000;
                            break;
                        case 'cm':
                            this.width *= 100;
                            this.height *= 100;
                            break;
                        default:
                            break;
                    }
                    break;
            }
            this.unit = unit;
        }

        toString() {
            return super.toString() + `width: ${this.width}, height: ${this.height}`;
        }
    }

    return { Figure, Circle, Rectangle };
}

let classes = generateClasses();
let Figure = classes.Figure;
let Rectangle = classes.Rectangle;
let Circle = classes.Circle;

let c = new Circle(5);
console.log(c.area, 78.53981633974483, "1");
console.log(c.toString(), "Figures units: cm Area: 78.53981633974483 - radius: 5", "2");
let r = new Rectangle(3, 4, 'mm');
console.log(r.area, 1200, "3");
console.log(r.toString(), "Figures units: mm Area: 1200 - width: 30, height: 40", "4");
r.changeUnits('cm');
console.log(r.area, 12, "5");
console.log(r.toString(), "Figures units: cm Area: 12 - width: 3, height: 4", "5");

c.changeUnits('mm');
console.log(c.area); // 7853.981633974483
console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50