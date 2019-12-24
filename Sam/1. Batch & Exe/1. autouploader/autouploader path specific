set /P schijf="welke schijf?"
%schijf%
set /p pad="geef het hele pad op beivoorbeeld /map/gitfolder/    "
cd %pad%
git pull
git add .
set /P commit="hoe wil je de wijziging noemen?  "
git commit -m "%commit%"
git push

pause
