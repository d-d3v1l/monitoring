const csv = require('csvtojson');

const detectErrors = (csvFilePath, errors, fn) => {
    return csv()
    .fromFile(csvFilePath)
    .then((jsonObj)=>{
        let hasChanges = false;
        let newErrors = {};
        jsonObj.forEach((log) => {
            const value = log['Task Logs']
            
            // searched word
            if (value.includes('failed')) {
                const date = value.slice(0, 19);
                const logInfo = value.slice(20);
                // check if the errors object has the same date as a key
                if (!errors.hasOwnProperty(date)) {
                    hasChanges = true;
                }
                newErrors[date] = logInfo
            } 
        }) 
        return {hasChanges, newErrors}
    })
}

module.exports = {
    detectErrors
}