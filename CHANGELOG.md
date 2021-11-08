# Changelog

`FSharp.Data.Migrations` is a simple database migration utility library.

All notable changes to this project will be documented in this file.

## [Unreleased]

- Add the ability to run `up` and `down` migrations
  - The default should be `up` only.
  - Identified in a script by @tags in a SQL comment
    - `--- @UP`
    - `--- @DOWN`
  - Parse the script file for `up` and `down` identifier comments
- Logger
  - Coloured console output
    - Make the `log writer` more sophisticated
  - A Verbose `MigrationsOption` for more logging output.
- Possibly change the project name and `namespace`.

## [0.1.1] - 2021-11-08

### Fixed

- Fixed a logic bug with the `TransactionScope` implementation.

## [0.1.0] - 2021-11-06

### Added

- Initial project release.
- Supports `PostgreSQL` byt default.
- All `MigrationOption` details are set for `PostgreSQL`.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).