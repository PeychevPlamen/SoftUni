function crew(worker) {

    if (worker.dizziness) {

        worker.dizziness = false;
        worker.levelOfHydrated += 0.1 * worker.weight * worker.experience;

    }
    return worker;
}
console.log(crew({
    weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true
}
));