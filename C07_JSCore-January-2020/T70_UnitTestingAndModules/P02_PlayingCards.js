function factory (face,suit){
    const faces = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
    const suits = {
        "S": "\u2660",
        "H": "\u2665",
        "D": "\u2666",
        "C": "\u2663"
    };

    class Card{
        constructor(face,suit){
            this.face = face;
            this.suit = suit;
        }

        set face(value){
            if (!faces.includes(value)) {
                throw Error("Error");
            }

            this._face = value;
        }

        get face(){
            return this._face;
        }

        set suit(value){
            if (!Object.keys(suits).includes(value)) {
                throw Error("Error");
            }

            this._suit = suits[value];
        }

        get suit(){
            return this._suit;
        }

        toString(){
            return `${this.face}${this.suit}`;
        }
    }

    let card = new Card(face, suit);
    return card.toString();
}
console.log(factory('A', 'S'));
console.log(factory('10', 'H'));
console.log(factory('J', 'D'));