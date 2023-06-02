
# CoinPayment.Net

This is a very simple library for consuming [Coinpayments](https://coinpayments.net).

## How to use

```c#
CoinApi api = new CoinApi(PublicApiKey,PrivateApiKey);
```

### Generate a receive payment request

```c#
api.ReceiveAsync(ReceiveTransaction transaction);