# Comandos iniciais:
``` bash
  mkdir api-desafio21dias-pais
  cd api-desafio21dias-pais
  dotnet new webapi
```

# Comandos git:
``` bash
  code .gitignore 
```
#### Gerei o conteúdo para ignorar como (Windows, Linux, Mac, DotnetCore, VisualStudioCore) no link: https://www.toptal.com/developers/gitignore
- Criei o repositório e rodei os comandos

``` bash
  git init
  git add .
  git commit -m "Iniciando projeto"
  git remote add origin git@github.com:torneseumprogramador/api-desafio21dias-pais.git
  git branch -M main
  git push -u origin main
```

# Componentes instalados:
``` bash
  dotnet add package mongocsharpdriver --version 2.13.1
  dotnet add package Newtonsoft.Json --version 12.0.3
```
