# installing dotnet
# Those above will prompt for root pass and user input

curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.gpg
sudo mv microsoft.gpg /etc/apt/trusted.gpg.d/microsoft.gpg
sudo sh -c 'echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-ubuntu-xenial-prod xenial main" > /etc/apt/sources.list.d/dotnetdev.list'
sudo apt-get update
sudo apt-get install dotnet-sdk-2.1.4
sudo apt-get install dotnet-sdk-2.2=2.2.203-1


# installing and launching DB

sqllocaldb start

add-migration <name>
update-database
