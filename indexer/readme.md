


curl  -d '{"text":"протокол"}' -H "Content-Type: application/json" -X POST localhost:9200/documents/_analyze 



http://localhost:5601 

http://localhost:9200 


localhost:9200/documents/_search?q=монополия


привет монополия AND group:"Решения" AND rubric:"Анти" AND start>2017

http://localhost:5601/app/kibana#/discover?_g=()&_a=(columns:!(_source),index:fe217e20-aad3-11e9-88a5-096be67884bd,interval:auto,query:(language:kuery,query:'%D0%BF%D1%80%D0%B8%D0%B2%D0%B5%D1%82%20%D0%BC%D0%BE%D0%BD%D0%BE%D0%BF%D0%BE%D0%BB%D0%B8%D1%8F%20AND%20group:%22%D0%A0%D0%B5%D1%88%D0%B5%D0%BD%D0%B8%D1%8F%22%20AND%20rubric:%22%D0%90%D0%BD%D1%82%D0%B8%22%20AND%20start%3E2017'),sort:!(_score,desc))