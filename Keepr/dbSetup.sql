CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS keeps(
  id int NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId varchar(255) COMMENT 'Creator Id',
  name varchar(255) COMMENT 'Keep Name',
  description varchar(255) COMMENT 'Keep Description',
  img varchar(255) COMMENT 'Keep Picture',
  views int NOT NULL DEFAULT 0,
  shares int NOT NULL DEFAULT 0,
  keeps int NOT NULL DEFAULT 0
) default charset utf8 COMMENT '';
DROP TABLE keeps;
CREATE TABLE IF NOT EXISTS vaults(
  id int NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'Vault Name',
  description varchar(255) COMMENT 'Vault Description',
  creatorId varchar(255) COMMENT 'Creator Id',
  isPrivate TINYINT NOT NULL DEFAULT 0
) default charset utf8 COMMENT '';
DROP TABLE vaults;
CREATE TABLE IF NOT EXISTS vaultkeeps(
  id int NOT NULL PRIMARY KEY AUTO_INCREMENT COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  vaultId int COMMENT 'Vault Id',
  keepId int COMMENT 'Keep Id',
  creatorId varchar(255) COMMENT 'Creator Id'
) default charset utf8 COMMENT '';
DROP TABLE vaultkeeps;

  SELECT 
      v.*,
      a.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE v.isPrivate = 0;
      SELECT
      v.*,
      a.*
      FROM vaults v
      JOIN accounts a ON a.id = v.creatorId
      WHERE v.id = 3 AND v.isPrivate = 1;

      SELECT * FROM vaults; 