E:
cd git
git pull
git add .
set /P commit="hoe wil je de wijziging noemen?"
git commit -m "%commit%"
git push
@echo als het niet heefd gewerkt moet je alle commandos zelf invoeren in een shell
pause
