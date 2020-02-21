function printDeckOfCards(cards) {
    const faces = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
    const suits = {
        "S": "\u2660",
        "H": "\u2665",
        "D": "\u2666",
        "C": "\u2663"
    };

    class Card {
        constructor(face, suit) {
            this.face = face;
            this.suit = suit;
        }

        set face(value) {
            if (!faces.includes(value)) {
                throw Error("Error");
            }

            this._face = value;
        }

        get face() {
            return this._face;
        }

        set suit(value) {
            if (!Object.keys(suits).includes(value)) {
                throw Error("Error");
            }

            this._suit = suits[value];
        }

        get suit() {
            return this._suit;
        }

        toString() {
            return `${this.face}${this.suit}`;
        }
    }

    let result = [];

    for (const currentCard of cards) {
        let face = currentCard.substr(0, currentCard.length - 1);
        let suit = currentCard[currentCard.length - 1];

        try {
            let card = new Card(face, suit);
            result.push(card.toString());
        } catch (error) {
            console.log(`Invalid card: ${currentCard}`);
            return;
        }
    }

    console.log(result.join(' '));
}

printDeckOfCards(['3D', 'JC', '2S', '10H', '5X']);
