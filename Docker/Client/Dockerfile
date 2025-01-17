FROM ubuntu:20.04

EXPOSE 8888

WORKDIR /root
ARG BRANCH

RUN DEBIAN_FRONTEND=noninteractive apt-get update && apt-get upgrade -y
RUN DEBIAN_FRONTEND=noninteractive apt-get install -y curl jq python3 ansible tar bash ca-certificates git openssl unzip wget python3-pip sudo acl build-essential python3-dev python3.8-venv python3.8-distutils apt nfs-common python-is-python3

RUN wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb \
&& dpkg -i packages-microsoft-prod.deb

RUN DEBIAN_FRONTEND=noninteractive apt-get update \
&& apt-get install -y apt-transport-https \
&& apt-get update
RUN DEBIAN_FRONTEND=noninteractive apt-get -y install tzdata dotnet-sdk-5.0

WORKDIR /root

RUN echo "Cloning ChiaPool"
RUN git clone https://github.com/Playwo/ChiaPool.git \
&& cd ChiaPool/ChiaPool.Client \
&& dotnet publish --runtime linux-x64 --self-contained -o /root/manager \
&& chmod +x /root/manager/ChiaPool.Client 


#Only required for build
RUN DEBIAN_FRONTEND=noninteractive apt-get purge -y dotnet-sdk-5.0 apt-transport-https \ 
&& apt-get autoremove -y

WORKDIR /root

RUN echo "Cloning chia-blockchain"
RUN git clone --branch ${BRANCH} https://github.com/Chia-Network/chia-blockchain.git \
&& cd chia-blockchain \
&& git submodule update --init mozilla-ca \
&& chmod +x install.sh \
&& /usr/bin/sh ./install.sh \
&& chmod +x activate \
&& mkdir ca

RUN mkdir /plots
WORKDIR /root
ADD ./entrypoint.sh entrypoint.sh

RUN DEBIAN_FRONTEND=noninteractive apt-get install -y dos2unix \
&& dos2unix entrypoint.sh \
&& apt-get autoremove -y

ENTRYPOINT ["bash", "./entrypoint.sh"]