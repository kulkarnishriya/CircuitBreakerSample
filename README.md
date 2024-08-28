This is a sample boilerplate for implementing retry and circuit breaker policy for a .Netcore application using Polly library.

** Publisher service **
This is an api service that publishes stock data. It can be accessed using an endpoint that returns stock data.

** Consumer service **
This controller calls the publisher API to get the stock data.

** Use case **
In many real time applications which calls another Http api, there might be transient failures such as service unavailable, intermitent issues. To deal with this, we need a retry policy.
Polly library provides configuring for retries. This particular code focuses on retry using polly and exponential back off policy.

Circuit breaker pattern is used to avoid cascading failures. If any api is down, the corresponding api calling it should not become unresponsive.
This particular code uses polly library to injest circuit breaker policy.

These policies are configured in program.cs.

This is a basic boilerplate and can be extended to your coding purpose.
