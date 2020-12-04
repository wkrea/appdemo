# Proyecto de Clase

> **Sugerencias**
>
> - Creen las cuentas [Github](https://github.com/) con sus correos institucionales
> - Verificar sus correos institucionales, por si Github les envia confirmación a sus correos
>
> **Modelo de Ramas del proyecto**
> ![https://drive.google.com/file/d/1Jv9G6kSf9m0mtrLpWj0YgQZN19pWV6yY/view?usp=sharing](Docs/imgs/branchModel.png)
> **Build Status**

|  Build   | Tests |   Coverage     |   Documentation  |
|-|-|-|-|
|![master](https://shorturl.at/nqFH5) |![shorturl](https://shorturl.at/nqFH5) | [![shorturl](https://shorturl.at/kprU7)](https://shorturl.at/pFLNU) | ![shorturl](https://shorturl.at/nqFH5)|
|![ApiFull](https://github.com/wkrea/appdemo/workflows/Aprendiendo%20con%20un%20web%20API%20.NET%20Core/badge.svg?branch=ApiFull&event=push)|-|-|-|

---

## Hacer Fork del repositorio

A continuación se presentan las secuencias de pasos para trabajar en este repositorio.
Hacer Fork del repositorio [https://github.com/wkrea/appdemo](https://github.com/wkrea/appdemo)

![Primeros pasos](./Docs/imgs/1.png)

1. Esperar que se cree el fork
![Esperar que se cree elk fork](./Docs/imgs/2.png)
2. verificar la correcta creación del fork
![verificar la correcta creación del fork](./Docs/imgs/3.png)

### 1. clonar el repositorio bifurcado a su PC`

1. Elija un lugar donde descargar los archivos del repositorio
2. abra una terminal **GitBash** en esa ruta
![abra una terminal **GitBash** en esa ruta](./Docs/imgs/4.png)
3. Ingrese el siguiente comando (*recuerde el ejemplo esta desarrollado con el usuario **wtrigos**, recuerde*)

  ``` bash
  git clone https://github.com/wkrea/appdemo
  ```

  ![git clone](./Docs/imgs/5.png)

Si todo va bien debería ver una carpeta `appdemo`

### 2. Desde el Fork **(de su repositorio)**, crear un branch **con el nombre de usuario de su correo institucional**

**Ejemplo**
Tomando como referencia al usuario `wtrigos1@udi.edu.co`

- Abriendo la consola git Bash, **DENTRO DE la carpeta del repositorio bifurcado**

`appdemo`, haga uso del comando:

```bash
git checkout -b nombre_branch
```

![git checkout -b nombre_branch](./Docs/imgs/6.png)

el comando anterior debe haber creado un nuevo brach (**a nivel local**), con el nombre `nombre_branch`

### 3. Actualizar el fork (Mantenerse al día con el profe)

A medida que el profesor trabaja, los cambios se ven reflejados en el repositorio [wkrea/appdemo](https://github.com/wkrea/appdemo).

Pero **su FORK** (su repositorio --> [malliwi/appdemo](https://github.com/wkrea/appdemo/network/members)), puede no estar al día con los cambios realizados por profesor

Para poder tener al día su **bifuración**(fork), emplee los siquientes comandos

> ⚠ **Este paso solo se requiere la primera vez**
>
> ```bash
> git checkout master
> git remote add upstream https://github.com/wkrea/appdemo.git
> ```
>
> ![add upstream](./Docs/imgs/7.png)

Estos deben ser ejecutados cada vez que se quiera actualizar

```bash
git checkout master
git fetch upstream
git rebase upstream/master
git push -f origin master
```

> **CUANDO TODO ESTÁ AL DíA**
    > ![fetch upstream normal](./Docs/imgs/8.png)
> **CUANDO, EXISTÍAN ACTUALIZACIONES QUE NO TENIAS**
    > ![fetch upstream rebasing](./Docs/imgs/8.1.png)

### Haciendo un Pull Request

Ahora si todo esta bien, y **SU Repositorio FORK** está al día, debería estar en capacidad de enviar aportes al profesor, **es decir, eso que llaman pull request!!! o PRs**, vamos a por ello!!! 🤓

- haga `git checkout nombre_branch`` **recuerde cambiar por su usuario!!, wtrigos es ejemplo**
- Actualice el archivo `control_avances.txt` ubicado en la **raiz del repositorio**, agregando su nombre de usuario Github (**ej: nombre_branch**) en el final del archivo, en una nueva linea.
- agregue los cambios a su branch, empleando `git add *`
- Haga el commit indicando como mensaje **nombre_branch modificó control_avances.txt**
- Haga `git push origin nombre_branch`
  > Esta imagen muestra la secuencia de pasos anterior, **tomando como ejemplo al usuario wtrigos**}
  > ![secuencia de pasos anterior](./Docs/imgs/9.png)
- Si todo va bien, debe ver los cambios en un nuevo branch en la pagina de su repositorio fork en [Github](https://github.com/)
    > ![debe ver los cambios en un nuevo branch](./Docs/imgs/10.png)
- hacer la solicitud de cambios al profesor (**crear el PULL REQUEST**)
  > ![hacer la solicitud de cambios al profesor](./Docs/imgs/11.png)
- verificar que la solicitud quedo en proceso!!!
  > ![verificar que la solicitud quedo en proceso](Docs/imgs/12.png)

## Referencias

- [Aprender Git branching Model Tutorial Interactivo español](https://learngitbranching.js.org/?locale=es_ES)
- [Actualizar el fork de un repositorio de GitHub](https://styde.net/actualizar-el-fork-de-un-repositorio-de-github/)
- [como borrar Braches](https://github.com/Kunena/Kunena-Forum/wiki/Create-a-new-branch-with-git-and-manage-branches)
- [Descartar cambios de archivos con Git](https://desarrolloweb.com/articulos/descartar-cambios-archivos-git.html)
- [Draw git flow Graphs with JS](https://www.nicoespeon.com/talk-drawing-git-graphs/#27)
- [Git workflow branching model](https://www.endoflineblog.com/oneflow-a-git-branching-model-and-workflow)
- [Building Commit Graphs](https://www.codebasehq.com/blog/building-commit-graphs)
- [git graphs0](https://livablesoftware.com/tools-to-visualize-the-history-of-a-git-repository/)
