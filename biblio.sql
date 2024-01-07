-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : dim. 07 jan. 2024 à 14:04
-- Version du serveur : 10.4.24-MariaDB
-- Version de PHP : 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `biblio`
--

-- --------------------------------------------------------

--
-- Structure de la table `blackliste`
--

CREATE TABLE `blackliste` (
  `CIN` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Structure de la table `cd`
--

CREATE TABLE `cd` (
  `code` int(11) NOT NULL,
  `auteur` varchar(50) NOT NULL,
  `titre` varchar(50) NOT NULL,
  `quantite` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `cd`
--

INSERT INTO `cd` (`code`, `auteur`, `titre`, `quantite`) VALUES
(2, 'hi', 'hello', 5),
(3, 'ilhame', 'helloo', 3),
(6, 'hi', 'hi', 5);

-- --------------------------------------------------------

--
-- Structure de la table `client`
--

CREATE TABLE `client` (
  `CIN` varchar(50) NOT NULL,
  `nom` varchar(50) NOT NULL,
  `prenom` varchar(50) NOT NULL,
  `telephone` varchar(50) NOT NULL,
  `adresse` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `client`
--

INSERT INTO `client` (`CIN`, `nom`, `prenom`, `telephone`, `adresse`, `email`) VALUES
('1', 'lamdibih', 'ilhame', '06212222', 'marrakech', 'ilhame@gmail.fr'),
('5', 'lamdibih', 'ilhame', '06212222', 'marrakech', 'ilhame@gmail.fr');

-- --------------------------------------------------------

--
-- Structure de la table `emprunt`
--

CREATE TABLE `emprunt` (
  `CIN` varchar(50) NOT NULL,
  `code` int(11) NOT NULL,
  `type` varchar(50) NOT NULL,
  `dateEmprunt` date NOT NULL DEFAULT current_timestamp(),
  `dateRetour` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `emprunt`
--

INSERT INTO `emprunt` (`CIN`, `code`, `type`, `dateEmprunt`, `dateRetour`) VALUES
('1', 3, 'CD', '2022-12-01', '0000-00-00'),
('1', 1, 'Livre', '2022-12-01', '0000-00-00'),
('1', 1, 'Periodique', '2022-12-01', '0000-00-00');

-- --------------------------------------------------------

--
-- Structure de la table `livre`
--

CREATE TABLE `livre` (
  `code` int(11) NOT NULL,
  `auteur` varchar(50) NOT NULL,
  `titre` varchar(50) NOT NULL,
  `quantite` int(11) NOT NULL,
  `editeur` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `livre`
--

INSERT INTO `livre` (`code`, `auteur`, `titre`, `quantite`, `editeur`) VALUES
(1, 'hi', 'hi', 4, 'hi');

-- --------------------------------------------------------

--
-- Structure de la table `periodique`
--

CREATE TABLE `periodique` (
  `code` int(11) NOT NULL,
  `auteur` varchar(50) NOT NULL,
  `titre` varchar(50) NOT NULL,
  `quantite` int(11) NOT NULL,
  `numero` int(11) NOT NULL,
  `nom` varchar(50) NOT NULL,
  `periodicite` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `periodique`
--

INSERT INTO `periodique` (`code`, `auteur`, `titre`, `quantite`, `numero`, `nom`, `periodicite`) VALUES
(1, 'meaw', 'meaw', 1, 2, 'meaw', '3');

-- --------------------------------------------------------

--
-- Structure de la table `utilisateur`
--

CREATE TABLE `utilisateur` (
  `userName` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `nomComplet` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `utilisateur`
--

INSERT INTO `utilisateur` (`userName`, `password`, `nomComplet`) VALUES
('ayoub', '123', 'CHAKIR Ayoub'),
('fati', '123', 'SALEH Fatimazehra'),
('ilhame', '123', 'LAMDIBIH Ilhame');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `cd`
--
ALTER TABLE `cd`
  ADD PRIMARY KEY (`code`);

--
-- Index pour la table `client`
--
ALTER TABLE `client`
  ADD PRIMARY KEY (`CIN`);

--
-- Index pour la table `livre`
--
ALTER TABLE `livre`
  ADD PRIMARY KEY (`code`);

--
-- Index pour la table `periodique`
--
ALTER TABLE `periodique`
  ADD PRIMARY KEY (`code`);

--
-- Index pour la table `utilisateur`
--
ALTER TABLE `utilisateur`
  ADD PRIMARY KEY (`userName`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `cd`
--
ALTER TABLE `cd`
  MODIFY `code` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT pour la table `livre`
--
ALTER TABLE `livre`
  MODIFY `code` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pour la table `periodique`
--
ALTER TABLE `periodique`
  MODIFY `code` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
