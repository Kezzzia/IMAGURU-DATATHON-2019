const needle = require('needle');
const cheerio = require('cherio');
const http = require('https');
const fs = require('fs');
const path = require("path");

const url = 'https://mart.gov.by/sites/mart/home/activities/komission/nedobrosovestnaya_konkurenciya.html';

function pDownload(url, dest) {
  var file = fs.createWriteStream(dest);
  return new Promise((resolve, reject) => {
    var responseSent = false; // flag to make sure that response is sent only once.
    http.get(url, response => {
      response.pipe(file);
      file.on('finish', () => {
        file.close(() => {
          if (responseSent) return;
          responseSent = true;
          resolve();
        });
      });
    }).on('error', err => {
      if (responseSent) return;
      responseSent = true;
      reject(err);
    });
  });
};

needle.get(url, (err, response) => {
  if (err) {
    console.log(err);
  }

  // console.log(response.body);

  const bodyC = cheerio.load(response.body);

  // console.log($('.pagecontent').text());

  const a = bodyC('.pagecontent a');

  // console.log(a);
  const arr = [];

  a.each((i, val) => {
    const prefix = 'https://mart.gov.by';
    const pageEntry = cheerio.load(val);
    const dateNumberQuery = pageEntry('span strong');
    var entry = {
      originalUrl : prefix + bodyC(val).attr('href'),
      
      
    };
    if (dateNumberQuery[0] && dateNumberQuery[0].children)
    {
      entry.possiblyDateAndNumber =  dateNumberQuery[0].children[0].data;
    }
    //console.error(entry.number);
    //console.error(entry.originalUrl);
    //console.error(Object.getOwnPropertyNames( dateNumberQuery));
    
    arr.push(entry);

  });

  var meta = [];

  // console.log(arr);
  arr.slice(1, 20).forEach((value, i) => {

    const val = value.originalUrl;
    console.log(val);
    const docName = path.basename(val);
    const outFile = './archive/' + i + ".pdf";
    pDownload(val, outFile)
      .then(() => console.log('downloaded file no issues...'))
      .catch(e => console.error('error while downloading', e));

    var item =
    {
      originalUrl: val,
      sequence: i,
      outFile : outFile,
      heading:"Недобросовестная конкуренция",
      possiblyDateAndNumber: value.possiblyDateAndNumber,

    };

    meta.push(item);
  });
  fs.writeFile("index.json", JSON.stringify( meta ), "utf8", (err) => console.log("fuck") );

});