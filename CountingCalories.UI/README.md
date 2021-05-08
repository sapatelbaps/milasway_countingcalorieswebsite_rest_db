both Api and UI projects worked after allowing permission to localhost.pfx certificate key file in MPi.
dotnet run was working but might be some bug in code or EF issue could not do CRUD operations.

Follow [steps](https://stackoverflow.com/questions/55485511/how-to-run-dotnet-dev-certs-https-trust/59702094#59702094) to install SSL cert in RPi ubuntu to make the projects work.

```
"Kestrel": {
    "Certificates": {
      "Default": {
        "Path": "localhost.pfx",
        "Password": ""
      }
    }
  },
```