# IotEdgeHostedWeb

## Overview

This repo contains the definition for a set of modules to show off some examples of local communication between modules outside of the message routing provided by the IoT Hub/Agent modules.

The modules included or referenced in this manifest are:

1. SampleModule - Basic sample module that is created from the IoT Hub Toolkit Extension in VS Code
2. SimulatedTemperatureSensor - Basic sample module that is created from the IoT Hub Toolkit Extension in VS Code (no source code)
3. WebModule - A DotNet Core WebAPI module exposed on port 8080
4. SQLServerModule - SQL Server exposed on port 1401 (no source code)

Both the WebModule and SQLServerModule show how to host services on IoT Edge that are not directly processing incoming messages. They both emit messages upstream that are consumed by IoTHub

The SimulatedTempuratureSensor emits telemetry that is consumed by the SampleModule which passes the telemetry through to IoTHub.

Before publishing to the IoT Edge runtime device, you will need to create a .env file that includes the username and password for your container registry (referenced as variables in the deployment.template.json files)
