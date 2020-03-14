function constructionCrew(worker){
    const requiredAmountMl = 0.1;

    if (worker.dizziness) {
        worker.levelOfHydrated += requiredAmountMl * worker.weight * worker.experience;
        worker.dizziness = false;
    }

    return worker;
}