'use strict';
function solution(worker){
    function hydration(worker){
        if(worker.dizziness){
            worker.levelOfHydrated += 0.1*worker.weight*worker.experience;
            worker.dizziness = false;
        }
    }
    hydration(worker);
    console.log(worker);
    return worker;
}
solution({ weight: 95,
    experience: 3,
    levelOfHydrated: 0,
    dizziness: false });