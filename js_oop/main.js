// Create File data.json input array([])

// Import Lib
const fs = require("fs");
const readline = require("readline");

// Reducer
const reducers = (accumulator, currentValue) => accumulator + currentValue;

// Functional QueryIndex
const QueryIndex = (currentOwn,select)=>{
    let arraydata = currentOwn.map((data)=>{ return parseInt(data[select]) })
    return arraydata.reduce(reducers)
}

// WriteFile System
const BufferWriteFile = (path, currentArray) => {
    return fs.readFile(path, 'utf8', (err, data) => {
        let currentOwn = JSON.parse(data)
        Array.prototype.push.apply(currentOwn,currentArray)
        console.log(Object.keys(currentOwn).length);
        console.log({ 
            SumTime: QueryIndex(currentOwn,"Time"),
            SumOil : QueryIndex(currentOwn,"Oil")
        });
        fs.writeFileSync(path, JSON.stringify(currentOwn));
    })
};

// Class OOP
class Egg {
    constructor(egg, preple) {
        this.egg = egg;
        this.preple = preple;
        this.time;
    }
    load() {
        return {
            Time: (this.egg*5+2),
            Oil: this.egg * 2,
        };
    }
}

// Current Validate
const data = { input: process.stdin, output: process.stdout };
const rl = readline.createInterface(data);
let currentArray = []

let LoopRecursive = (member) => {
    if (member < 1) {
        rl.close()
        return BufferWriteFile('./data.json',currentArray)
    }
    rl.question("Enter amount of Egg :", (egg) => {
            currentArray.push(new Egg(egg,member).load())
            member--
            LoopRecursive(member)
    });
}

// Loop 
rl.question("Enter member :", (member) => {
    let memberint =  parseInt(member)
    LoopRecursive(memberint)
});
