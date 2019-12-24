E:
cd git
git pull
git add .
set /P commit="hoe wil je de wijziging noemen?"
git commit -m "%commit%"
git push
