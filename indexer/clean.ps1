curl -X DELETE localhost:9200/documents


# $r = Invoke-WebRequest -Uri  http://localhost:9200/_analyze -Method POST -Body '{"tokenizer": "standard", "analyzer" : "german", "text":"asd 123 монополия 345 έτος Weltanschauung"}' -Headers $headersdo