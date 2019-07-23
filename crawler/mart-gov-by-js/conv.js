const fs = require('fs');
const pdf = require('pdf-parse');
const path = require('path');

const directoryPath = path.join(__dirname, 'newPdf');

fs.readdir(directoryPath, function (err, files) {
  //handling error
  if (err) {
    return console.log('Unable to scan directory: ' + err);
  } 
  //listing all files using forEach
  
  files.forEach(function (file) {
      // Do whatever you want to do with the file
      console.log(file);

      let dataBuffer = fs.readFileSync('newPdf/' + file);

      pdf(dataBuffer).then(function(data) {

        const filePath = path.join(__dirname, 'test', file + '.txt');
    
        fs.writeFileSync(filePath, data.text, err => {
          if(err) {
            console.log(err);
          };
    
          console.log('ok');
        });
            
    });
  });
});