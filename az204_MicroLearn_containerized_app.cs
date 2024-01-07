/*Create Docker images and store them in a repository in Azure Container Registry.
Use App Service to run web apps that are based on Docker images held in Azure Container Registry.
Use webhooks to configure continuous deployment of a web app that's based on a Docker image*/

//create usig az cli
az acr create --name myregistry --resource-group mygroup --sku standard --admin-enabled true
//upload the docker file and CR will build image
az acr build --file Dockerfile --registry myregistry --image myimage .

//Build and store an image by using Azure Container Registry
///1. Create a registry in Azure Container Registry
///2. Build a Docker image and upload it to Azure Container Registry
///run the following command to download the source code for the sample web app.
git clone https://github.com/MicrosoftDocs/mslearn-deploy-run-container-app-service.git
///Move to the source folder.
cd mslearn-deploy-run-container-app-service/dotnet
///send the folder's contents to the Container Registry, 
az acr build --registry <container_registry_name> --image webimage .
///3.Examine the container registry
///Container registry pane-> under Services, select Repositories.

//Deploy a web app by using an image from an Azure Container Registry repository
/*Startup file: This item is the name of an executable file or a command to be run when the image is loaded. 
It's equivalentto the command that you can supply to Docker when loading an image from the command
line by running docker run*/
///1. Enable Docker access to the Azure Container Registry
///The Container Registry enables you to set the registry name as the username and the admin access key as the password to allow Docker to log in to your container registry.
///Check the Admin user box. 
///2.Create a web app
///	On the Docker tab,Image Source: Azure Container Registry,Image:webimage,Tag:latest and create
///3.Test the web app
///App service pane-->browse

//Update the image and automatically redeploy the web app:
/// 1. webhook: web app that uses App Service can subscribe to a Container Registry webhook to receive 
/// notifications about updates to the image that contains the web app.
/// App service->Deployment Center->Registry settings->Continuous Deployment to On.
///2. use the tasks feature of Container Registry to rebuild your image whenever its source code changes automatically
///3. Enable continuous integration from App Service -> Container settings page of an App Service
///4. Extend continuous integration to source control by using an Azure Container Registry task.
///az acr task create command creates and registers a long-lived task.
az acr task create --registry <container_registry_name> --name buildwebapp --image webimage --context https://github.com/MicrosoftDocs/mslearn-deploy-run-container-app-service.git --file Dockerfile --git-access-token <access_token>