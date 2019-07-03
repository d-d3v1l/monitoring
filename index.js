const fs = require('fs');
const csvFilePath = '../TXT FILES/TaskLogsPSP-STG.csv'

const app = require('express')();
const http = require('http').createServer(app);
const io = require('socket.io')(http);
const { detectErrors } = require('./detect-errors.js')

let socketInstance = null;
let errors = {};

// nodemon to start the server

const sendErrors = (socket, errorsObj) => {
  socket && socket.emit('new errors', errorsObj)
}

fs.watchFile(csvFilePath, (curr, prev) => {
    detectErrors(csvFilePath, errors)
    .then(({hasChanges, newErrors}) => {
        if(hasChanges) { 
            errors = newErrors;
            sendErrors(socketInstance, errors)
        }
        console.log('errors', errors);
        console.log('has new errors', hasChanges);
    });
});

io.on('connection', function (socket) {
    socketInstance = socket;
});

http.listen(3000, function () {
    console.log('listening on *:3000');
});

