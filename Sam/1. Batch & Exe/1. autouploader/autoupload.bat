@echo "you need to put in your own information and path info
E:
cd git
git pull
git add .
set /P commit="hoe wil je de wijziging noemen?"
git commit -m "%commit%"
git push
pause
