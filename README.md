# HelloWorld
HelloWorld of C# Demo Application

教学示例程序

## 日志
2024.10.23 加入线路计算程序SmartRoute，重构了整个解决方案对架构，将原SurApp更名为ProjApp。
2024.10.24 将整个解决方案名称改为SurApp
2024.10.27 VM中将XyToBl 与 BlToXy 加入到多线程环境 
2024.10.28 将排序结果用WinForm形似进行展示

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
