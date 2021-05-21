function stringLength(strOne, strTwo, strThree) {

    let strSum = strOne.length + strTwo.length + strThree.length;
    let averageStrLength = (strOne.length + strTwo.length + strThree.length) / 3;

    //let averageStrLength = (strOne.length + strTwo.length + strThree.length) / arguments.length;

    console.log(strSum);
    console.log(Math.round(averageStrLength));

    //console.log(strOne.length + strTwo.length + strThree.length);
    //console.log(Math.round((strOne.length + strTwo.length + strThree.length) / 3));
}
//stringLength('chocolate', 'ice cream', 'cake');