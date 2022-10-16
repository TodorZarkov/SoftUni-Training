function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let restaurants = [];
      let input = JSON.parse(document.getElementById('inputs').children[1].value);

      for (let inputData of input) {
         let [name, workerList] = inputData.split(' - ');
         if (restaurants[name] === undefined) {
            restaurants[name] = {
               avgSalary: 0,
               bestSalary: 0,
               sumSalary: 0,
               workerList: [],
               workersCount: 0
            };
         }
         //update result
         let workersData = workerList.split(/[\s,]+/gm);
         for (let i = 0; i < workersData.length; i += 2) {
            let workerName = workersData[i];
            let workerSalary = Number(workersData[i + 1])
            restaurants[name].workerList[workerName] = workerSalary;
            restaurants[name].sumSalary += workerSalary;
            if (restaurants[name].bestSalary < workerSalary) {
               restaurants[name].bestSalary = workerSalary;
            }
            restaurants[name].workersCount++;
         }
      }
      //update avarageSalary
      let bestKey;
      let iter = 0;
      for (let key in restaurants) {
         if (iter === 0) {
            bestKey = key;
            iter++;
         }
         restaurants[key].avgSalary = restaurants[key].sumSalary / restaurants[key].workersCount;
         if (restaurants[key].avgSalary > restaurants[bestKey].avgSalary) {
            bestKey = key;
         }
      }
      //getting outputs
      let output1 = `Name: ${bestKey} Average Salary: ${restaurants[bestKey].avgSalary.toFixed(2)} Best Salary: ${restaurants[bestKey].bestSalary.toFixed(2)}`;

      let sortableWorkers = [];
      for (const worker in restaurants[bestKey].workerList) {
         let salary = restaurants[bestKey].workerList[worker];
         sortableWorkers.push([worker, salary])
      }
      let sortedWorkers = sortableWorkers.sort((b,a) => a[1] - b[1]);

      let output2 = [];
      for (let i = 0; i < sortedWorkers.length; i++) {
         output2[i] = `Name: ${sortedWorkers[i][0]} With Salary: ${sortedWorkers[i][1]}`;
      }
      output2 = output2.join(' ');

      //setting outputs
      document.querySelector('#bestRestaurant p').textContent = output1;
      document.querySelector('#workers p').textContent = output2;

   }
}