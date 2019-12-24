#going to the drive insert your own path
E:
cd git
#getting updates from the repo
git pull
#uploading
git add .
# you can change (hoe wil je de wijzigingen noemen)
set /P commit="hoe wil je de wijziging noemen?"
git commit -m "%commit%"
git push
#uploading done
