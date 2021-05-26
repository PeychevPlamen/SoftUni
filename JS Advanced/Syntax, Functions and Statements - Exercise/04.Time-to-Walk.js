function solve(steps, footprintInMeters, speedInKm) {

    let speedInMeters = (speedInKm * 1000) / 3600;
    let distance = steps * footprintInMeters;

    let rests = Math.trunc(distance / 500) * 60;

    let totalTime = distance / speedInMeters + rests;

    let hours = Math.trunc(totalTime / 3600);
    let minutes = Math.trunc((totalTime % 3600) / 60);
    let seconds = Math.round(totalTime % 60);

    return (`${hours.toString().padStart(2, "0")}:${minutes.toString().padStart(2, "0")}:${seconds.toString().padStart(0, "2")}`);
}

// console.log(solve(4000, 0.60, 5));
// console.log(solve(2564, 0.70, 5.5));
