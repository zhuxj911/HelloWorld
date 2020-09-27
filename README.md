# HelloWorld
HelloWorld of C# Demo Application

## git branch

###  查看当前有哪些分支
$ git branch

###  新建一个分支  git branch    (branchname)
$ git branch dev2

### 切换到指定分支  git checkout (branchname)
$ git checkout dev2
$ # 再次查看分支
$ git branch
* dev2
  master
  
 ### 查看本地和远程分支
 $ git branch -a
* dev2
  master
  remotes/origin/HEAD -> origin/master
  remotes/origin/master
   
### 合并某个分支到当前分支  git merge
合并分支：dev2 到当前分支(master)

$ git branch
  master
* dev2

$ git checkout master

$ git merge dev2

### 修改分支的名字
$ git branch
* dev2
  master

$ git branch -m dev2 version.2

$ git branch -r
  origin/HEAD -> origin/master
  origin/dev2
  origin/master
  
   ### 删除分支 git branch -d (branchname)
   
  ### 删除远程分支
  $ git branch
  master
* version.2

$ git push origin --delete dev2
