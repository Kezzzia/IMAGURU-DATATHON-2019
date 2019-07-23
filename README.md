# IMAGURU-DATATHON-2019

__Technical task__:

https://docs.google.com/document/d/1IpYbRPMz2oHh4VSj5PMx5ZihH5UZPuVGIWXxmu7ItlY/edit# 

# Антимонопольный закон

- статья 18 (злоупотребление доминирующим положением)
- статья 29 (недобросовестная конкуренция, смешение)

Same Decision may be in 2 Groups

# Подборка

Автоматической подборкой имеющихся разъяснений АО, других документов по теме (в том числе решений Верховного суда по обжалованиям решений), а также подборкой новостей (форумов где обсуждается) из сети по данному решению. 

Решения, Разъяснения, Новости, Комментарии, Обсуждения.

# Россия

Разъяснения от ФАС России по вопросу, являющемуся предметом решения. Например, если дело касается недобросовестной конкуренции в форме смешения, то в подборке также появляется ссылка на «<Письмо> ФАС России от 30.06.2017 N АК/44651/17 "О практике доказывания нарушений, квалифицируемых в соответствии с пунктом 2 статьи 14.6 "О защите конкуренции"».

База решений в Российской Федерации (с пометкой «РФ»). 

Разъяснения - http://fas.gov.ru/documents/type_of_documents/clarifications

База решений и правовых актов - https://br.fas.gov.ru/

Новостные порталы - https://ria.ru/ , https://www.gazeta.ru/ , https://www.rbc.ru , https://www.vedomosti.ru , https://tass.ru/ , http://www.interfax-russia.ru/


# Seaches and facets

https://mart.gov.by/sites/mart/home/search-results.html?jcrMethodToCall=get&src_originSiteKey=mart&src_terms%5B0%5D.term=%D1%80%D0%B5%D1%88%D0%B5%D0%BD%D0%B8+%D0%BC%D0%BE%D0%BD%D0%BE%D0%BF%D0%BE%D0%BB%D1%8C&src_terms%5B0%5D.applyFilter=true&src_terms%5B0%5D.match=as_is&src_terms%5B0%5D.fields.siteContent=true&src_terms%5B0%5D.fields.files=true&src_nodeType=nt%3Abase&src_sites.values=mart&src_sitesForReferences.values=systemsite&src_languages.values=da

# Areas

# Data sets

- we have 2 cases of decisions+related,

- need 10+ more for belarus, 30 would be ideal

- ensure each data source is covered

# Statistics and Logic

Улучшение поиска статистическими методами:

- вычисление синонимов и использование их в поиске
- классификация источников текстов на релевантность монопольным делам и группам дел для автоматического пополнения базы
- вычисление связи к конкретным делам для группового отображения и рекомендаций
- получение деталей из документов(даты, стороны, организации, заключения, номера дел и статей) и использование в поиске
- сбор информации действиях пользователей и кликах для последующего улучшения

Внесение знаний и логики предметной области, а также покрытие больше числа источников(включая российские) так же позволят значительно улучшить качество.

- detect-classify relevant and not relevan news
- detect type of relevan source - Разяъяснени or Other
- detect document to document relation for different headigs, learn from user activity (clicks)
- detect imporat details in document like insitute, date effective, numbers, importan areas. Can use infromation of meta from crawelr (like title) or from document body
- identify sides in
- learn out synonics from domain and create data set
- detect reference from "Решение" "Верховный суд" into "Решение" "Антимонопольный орган", search for number and date
- introduce law related relation and pracitec (document numbering, possible relations) as raw logic into code
- прогнозирования успешности обжалования решения. антимонопольный орган принимает решение, система анализирует его и на основе решений суда по схожей теме выдает какой-то прогноз будет ли обжалование решения в суде успешным
- for each of above propose possible solution
- inroduce domains knowledege
```
злоупотребление доминирующим положением, в новом законе это статья 18, в старом - 12;
антиконкурентные соглашения и согласованные действия - новый - статьи 20,21, старый - 13
недобросовестная конкуренция - новый:25-31, старый -16
антиконкурентные действия гос. органов - новый:23, старый:15
нарушение требований к закупка - есть только в новом - 24
```
- some docs are scans!!!!

## Tech

- Crawl-archive web pages using standard engines
- Ensure proper crawler runtime (different IPs and scale in virtual machines(same for other tasks)), 
- Conver documentrs (pdf, doc, html) into text and near native html
- setup sheduler of runs
- Write down specific crawler for each source
- Parse archive for extracting metadata and tags
- Run classfiers on tags and texts
- Run connected classifiers (if there is decisiton than document about it is monopoly)
- Run entity recognisions on meta and bodies
- Put all proper tags, relatios, meta and body into search database
- Show recomendated documents
- Collect users activity of clicks on recomedation and other analytics
- Allow dismis relation (hide for this user, downscore for others)
- build proper api aboce search database and our knowledeg
- Inegratre russion knowledge
- Modifu UI to proper mockups


# Presentation:




