  1. Pattern History
> 2. Introduction to MVVM
> > a. Covered
> > > i. Shared Session State via Inotify
> > > ii. Separated View State and View Logic in the VM

> > b. Not covered
> > > i. Validations
> > > ii. Touched hierarchical VMs (HVM)
> > > iii. Persistence
> > > iv. Enterprise Architecture
        1. ORM to Model
> > > > 2) Repository
> > > > 3) Unit of Work
> > > > 4) Concurrency

> 3. Northwind I
> > a. Introduce Northwind
> > > i. Requirements

> > b. Topics
> > > i. Expand on HVM by introducing tabs
> > > ii. Demonstrate EF integration
        1. change notifications
> > > iii. Commands
        1. Event behavior
> > > > 2) Relay Commands
> > > > > a) MVVM Light

> > > iv. Data templates for mapping views
> > > v. Architecture
        1. Entity Framework
> > > vi. ViewModel and Model Properties
        1. Proxy Properties
> > > > 2) Model aggregation

> > c. Features
> > > i. Customer list
        1. Open
> > > ii. Collapsible control panel
> > > iii. Customer details
        1. Edit
> > > > > a) Disable\enable
> > > > > b) Save
> > > > > c) Delete

> 4. Northwind II
> > a. Topics
> > > i. Architecture
        1. DataServices
> > > > 2) Other options (discussion)
> > > > > a) DAL
> > > > > > i) Transaction Script
> > > > > > ii) Table Module
> > > > > > iii) DDD (Domain Model)

> > > > > b) Persistence Ignorance
> > > > > > i) Repository
> > > > > > ii) UoW

> > > ii. Multi-targeting

> > b. Features
> > > i. Silverlight client
> > > ii. Unit tests

> 5. Northwind III
> > a. Issues with current design
> > b. Topics
> > > i. Deep dive on HVM
> > > ii. IoC
> > > iii. DI
        1. Ninject
> > > iv. Locator Pattern
> > > v. View Model instantiation

> > c. Features
> > > i. Control panel
        1. HVM
> > > > 2) Order CP

> > > ii. Locator Service
> > > iii. IoC via Ninject
> > > iv. Orders
        1. Listed

> 6. Northwind IV
> > a. Issues with current design
> > b. Topics
> > > i. 3rd Party aggregation

> > c. Features
> > > i. Orders
        1. Create
> > > > > a) WF
> > > > > b) Attached behaviors

> > > ii. Application Model and Settings
> > > iii. MDI

> 7. Validations
> 8. Blendability
> 9. Advanced  Topics
> > a. Synchronization, threading and collections
> > b. Notifying VM when V event like animation complete
> > c. View throttling
> > d. Performance Improvements
> > e. Dynamic Properties
> > f. Messaging
> > > i. Save all in Northwind on close
  1. . Appendix A

> > a. MVVM Cheat sheet
  1. . Appendix B
> > a. MVVM Frameworks
  1. . Appendix C
> > a. Binding Cheat Sheet