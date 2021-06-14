function playingCards(face, suit) {

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
console.log(playingCards('A', 'S'));
console.log(playingCards('10', 'H'));
console.log(playingCards('1', 'C'));