# to use this dockerfile (from within current dir):
# 2. docker build -t ui:1.0 .
# 3. docker run --rm -it ui:1.0

##### V1 ######

        # FROM mcr.microsoft.com/dotnet/sdk:5.0

        # WORKDIR /app

        # COPY . ./

        # CMD [ "dotnet", "run" ]
        # # issues:
        # # 1. the source code is in the image
        # # 2. image size much larger (inclusion of whole SDK)
        # # 3. we're compiling the code when container starts,
        # #   not when image builds

##### V2 ######
FROM mcr.microsoft.com/dotnet/sdk:5.0

WORKDIR /app

COPY . ./

# RUN dotnet build
RUN dotnet publish 'Project 0'/UI -o publish

# CMD [ "dotnet", "run", "--no-build" ]
CMD [ "dotnet", "publish/UI.dll" ]
# fixes issue #3 from V1, issues #1 and #2 still remain

# exercise:
# 1. dockerize your project 0 (with build in the image)
#    (up to either successful or failed DB connection)
# 2. dockerize your project 1 (with build in the image)
#    (up to either successful or failed DB connection)
#    (pass the connection string to docker run as an environment
#    variable with name like: "ConnectionStrings__MySqlDb")
#    (consider why you shouldn't provide it with an ENV command
#    in the dockerfile)
# 3. look up online how to "properly" Dockerize an ASP.NET Core app
#    identify three differences from what you did in step 2
#    and research what those differences are for.
