//storing and sharing containers:
    //1. create registry
        a. az acr create (provide Rg, registry name, sku)
    //2. login into registry:
        a. az acr login --name(of registry) 
    //3. tag  a prebuild docker image before pushing
        a. docker tag c:\\myimage(path to local image) my-uni-acr.azurecr.io(path to Registry)/204iamge(tag):v1
    //4. in case if image is not available;
        a. docker pull mcr.Microsoft.com/hello-world
    //5.tah will be now different.
       a. docker tag mcr.Microsoft.com/hello-world(path to  image) my-uni-acr.azurecr.io(path to Registry) / hello - world:v1(tag)
    //6.push a container docker image:
       a. docker push  204iamge:v1

//multi-steps process called docker file:
    //1.add automation and stuff 
//Acr task
    //1. automate container 