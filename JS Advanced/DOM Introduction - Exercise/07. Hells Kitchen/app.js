function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let result = [];
      let input = JSON.parse(document.getElementById('inputs').children[1].value);

      for (let inputData of input) {
         let [name, workerList] = inputData.split(' - ');
         if (!result.find(x => x.name === name)) {
            result.push({
               name,
               avgSalary : 0,
               bestSalary :0,
               sumSalary : 0,
               workerList : []
            })
         }
      }


   }
}