## [1.0.0] - 2025-01-18
### First Release
- Added the first release of the package.
## [1.0.1] - 2025-01-18
### Fixed
- Added missing dependencies to assembly definition.
## [1.0.2] - 2025-01-18
### Fixed
- Changed access modifiers from internal to public for ObservableScriptable Object.
## [1.0.3] - 2025-01-25
### Fixed
- Multiply instances of a persistent singleton.
### Refactor
- SingletonScriptableObject.
## [1.0.4] - 2025-01-30
- Resource path usage
### Feat
## [1.0.5] - 2025-03-10
- Reset Instances for non domain-reload mod
### Fix
## [1.0.6] - 2025-03-14
- Fix PersistentSingletonBehavior lifetime management. 
### Fix
## [1.0.7] - 2025-03-14
- Fix build issue this access modifier.
### Feat
## [1.0.8] - 2025-03-14
- Added link.xml to provide the ability to set high managed stripping level. 
## [1.0.9] - 2025-03-15
### Refactor
- Remove link.xml
- Remove dependencyinjection dependency
### Fix
- Fix error on build when managed stripping level set to high
## [1.0.10] - 2025-03-17
### Refactor
- OnDestroyed event reset
## [1.0.11] - 2025-03-17
### Refactor
- Was removed IDisposable for Singleton.cs.