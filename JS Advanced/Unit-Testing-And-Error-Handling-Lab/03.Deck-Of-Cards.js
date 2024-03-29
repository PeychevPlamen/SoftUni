function printDeckOfCards(cards) {

    let result = cards.reduce((acc, val) => {
        let face = val.slice(0, -1);
        let suit = val.slice(-1);

        try {

            let card = createCard(face, suit);
            return acc += ' ' + card;

        } catch (error) {

            console.log(`Invalid card: ${val}`)

            acc = '';
        };

    }, '');


    return result;


    function createCard(face, suit) {

        let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

        let validSuit = {
            'S': '\u2660',
            'H': '\u2665',
            'D': '\u2666',
            'C': '\u2663'
        };

        if (!validFaces.includes(face)) {
            throw new Error('Invalid face')
        }
        if (!Object.keys(validSuit).includes(suit)) {
            throw new Error('Invalid suit');
        }

        return `${face}${validSuit[suit]}`;
    }

}

console.log(printDeckOfCards(['AS', '10D', 'KH', '2C']));
console.log(printDeckOfCards(['5S', '3D', 'QD', '1C']));
// const deck1 = ['AS', '10D', 'KH', '2C'];
// const deck2 = ['5S', '3D', 'QD', '1C'];

// printDeckOfCards(deck1);
// printDeckOfCards(deck2);