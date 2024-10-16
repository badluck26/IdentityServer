CREATE TABLE AppUsers (
    Id uniqueidentifier DEFAULT NEWSEQUENTIALID(),
	CreationDate Datetime NOT NULL,
	UpdateDate DateTime NULL,
	CreatedBy nvarchar(32) NOT NULL,
    UpdatedBy nvarchar(32) NULL,
    Email nvarchar(255) NOT NULL,
	FirstName nvarchar(255) NOT NULL,
	LastName nvarchar(255) NOT NULL,
	PasswordHash nvarchar(60) NULL,
	LoginPolicyId uniqueidentifier UNIQUE,
	PRIMARY KEY (Id),
	FOREIGN KEY (LoginPolicyId) REFERENCES LoginPolicies(Id)
);

CREATE TABLE ExternalLogins (
    Id uniqueidentifier DEFAULT NEWSEQUENTIALID(),
	CreationDate Datetime NOT NULL,
	UpdateDate DateTime NULL,
	CreatedBy nvarchar(32) NOT NULL,
    UpdatedBy nvarchar(32) NULL,
	AppUserId uniqueidentifier NOT NULL UNIQUE,
	Authenticator nvarchar(32) NOT NULL,
	ExternalId uniqueidentifier NOT NULL UNIQUE,
	PRIMARY KEY (Id),
	FOREIGN KEY (AppUserId) REFERENCES AppUsers(Id)
);

CREATE TABLE LoginPolicies (
    Id uniqueidentifier DEFAULT NEWSEQUENTIALID(),
	CreationDate Datetime NOT NULL,
	UpdateDate DateTime NULL,
	CreatedBy nvarchar(32) NOT NULL,
    UpdatedBy nvarchar(32) NULL,
	AppUserId uniqueidentifier NOT NULL UNIQUE,
	LastLoginDate Datetime NOT NULL,
	IsBlocked bit DEFAULT(0) NOT NULL,
	UnblockDate Datetime NULL,
    FailedLoginAttempts int DEFAULT(0) NOT NULL,
	PRIMARY KEY (Id),
	FOREIGN KEY (AppUserId) REFERENCES AppUser(Id)
);
