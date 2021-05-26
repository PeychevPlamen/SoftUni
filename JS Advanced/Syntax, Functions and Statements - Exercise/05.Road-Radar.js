function solve(speed, area) {
    
    let speedLimit = 0;
    let status = '';
    let difference = 0;

    if (area === 'motorway') {
        speedLimit = 130;
    }
    else if (area === 'interstate') {
        speedLimit = 90;
    }
    else if (area === 'city') {
        speedLimit = 50;
    }
    else if (area === 'residential') {
        speedLimit = 20;
    }

    if (speed > speedLimit) {

        difference = speed - speedLimit;

        if (difference <= 20) {
            status = 'speeding';
        }
        else if (difference <= 40 && difference > 20) {
            status = 'excessive speeding';
        }
        else {
            status = 'reckless driving';
        }

        return `The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`;
    }
    else {

        return `Driving ${speed} km/h in a ${speedLimit} zone`;
    }

}
// console.log(solve(40, 'city'));
// console.log(solve(21, 'residential'));
// console.log(solve(120, 'interstate'));
// console.log(solve(200, 'motorway'));
