// Functional Programing
const readline = require("readline");
const data = {
  input: process.stdin,
  output: process.stdout,
};
const rl = readline.createInterface(data);
const main = () => {
  let currentArray = [];
  let totalEag = 0 
  let loopCount = 0
  const calTime = (egg, preple) => (time = egg * 5 + 2 * preple);
  const calPersonTime = (egg) => (time = egg * 5 + 2);
  const calOil = (egg) => egg * 2;
  const PEgg = (preple) => {
    if (preple < 1) {
      console.log("Time :" + calTime(totalEag,loopCount));
      console.log("Oil :"+calOil(totalEag));
      return rl.close();
    }
    rl.question("Enter amount of Egg :", (egg) => {
        totalEag += Number(egg)
        console.log({
          time:calPersonTime(egg, preple),
          oil:calOil(egg)
        });
        currentArray.push({
          time:calPersonTime(egg, preple),
          oil:calOil(egg)
        });
        preple--;
        loopCount+=1
        PEgg(preple);
    });
  };

  rl.question("How many person? :", async (preple) => {
    await PEgg(parseInt(preple));
  });
};
main();
