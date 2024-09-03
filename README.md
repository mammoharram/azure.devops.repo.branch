# azure.devops.repo.branch

1- you will need to create your PAT (Personal Access Token) from azure devo

	* Go to Azure Devo
	* Click on User Settings icon (top-right corner)
	* Click Personal Access Token
		* Read permission should be suffcient

2- add it in this line of code:

	string pat = "replace-with-your-personal-access-token";
3- Specify the file output path (where the results should be saved)

	string outputFilePath = "replace-with-file-path"; //ex: "C:\\Users\\output";

