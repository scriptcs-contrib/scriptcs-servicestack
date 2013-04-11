scriptcs-servicestack
============

## About

This is a [Script Pack](https://github.com/scriptcs/scriptcs/wiki/Script-Packs) 
for [scriptcs](https://github.com/scriptcs/scriptcs) that allows you to self-host [ServiceStack](https://github.com/ServiceStack/ServiceStack) services fast and easy :smile:

## Installation
To intall this Script Pack, simply navigate to your script folder and run `scriptcs -install ScriptCs.ServiceStack` :metal:

## Usage
Using the pack in your scripts is as easy as :cake:! After it has been installed, it will automatically be loaded (from the bin folder).

The pack will import the following namespaces:
 - ServiceStack.ServiceHost
 - ServiceStack.ServiceInterface

To use the packs utility methods in your scripts, use `Require<ServiceStackPack>` to get the Script Pack context.

The context has two methods for creating and running your service host:

```csharp
void StartHost(string urlBase, string serviceName = DefaultServiceName, Assembly serviceAssembly = null, Action<AppHostHttpListenerBase> configurationBuilder = null)
AppHostHttpListenerBase CreateHost(string serviceName = DefaultServiceName, Assembly serviceAssembly = null, Action<AppHostHttpListenerBase> configurationBuilder = null)
```

`DefaultServiceName` is "ScriptCs ServiceStack Host"

The `StartHost` method will create a host with the given settings and run it on the given url.

The `CreateHost` will only create the host object and return it.

## Sample

For a working sample application, please check out the [sample folder](https://github.com/khellang/scriptcs-servicestack/tree/master/sample)...

## Bugs and Feature Requests
If you find any bugs or would like to see new features/changes in this Script Pack, 
please let me know by [filing an issue](https://github.com/khellang/scriptcs-servicestack/issues/new) or sending a pull request :grin:
