



# $url = "https://artifacts.elastic.co/downloads/elasticsearch/elasticsearch-7.2.0-windows-x86_64.zip"

# Import-Module -Name SilentInstall

# $esArchive = Import-SilentFile $url

# Expand-Archive -Path $esArchive -DestinationPath "G:\src\hackatons\chaintrack\runtime" -Force

# $esgui = Import-SilentFile "https://artifacts.elastic.co/downloads/kibana/kibana-7.2.0-windows-x86_64.zip"

# Expand-Archive -Path $esgui -DestinationPath "G:\src\hackatons\chaintrack\runtime" -Force


#"elasticsearch.hosts: [`"http://localhost:9200`"]" | Out-File -Append "G:\src\hackatons\chaintrack\runtime\kibana-7.2.0-windows-x86_64\config\kibana.yml"




"http.cors.allow-origin: `/.*/`"" | Out-File -Append "G:\src\hackatons\chaintrack\runtime\elasticsearch-7.2.0\config\elasticsearch.yml"
"http.cors.enabled: true" | Out-File -Append "G:\src\hackatons\chaintrack\runtime\elasticsearch-7.2.0\config\elasticsearch.yml"


network.host: ["127.0.0.1", "10.168.1.107"]
http.port: 9200
discovery.seed_hosts: ["127.0.0.1", "10.168.1.107"]