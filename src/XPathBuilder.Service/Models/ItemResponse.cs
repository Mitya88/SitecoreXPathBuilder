namespace XPathBuilder.Service.Models
{
    using Sitecore.Data.Managers;

    public class ItemResponse
    {
        public ItemResponse(Sitecore.Data.Items.Item item)
        {
            this.Name = item.Name;
            this.Path = item.Paths.FullPath;
            this.Icon = GetIcon(item);
            this.HasChildren = item.HasChildren;
            this.ID = item.ID.ToString();
        }

        public bool HasChildren { get; set; }
        public string Icon { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public string ID { get; set; }

        /// <summary>
        /// Gets the icon of the item
        /// </summary>
        /// <param name="sitecoreItem">The item</param>
        /// <returns>The icon path</returns>
        public static string GetIcon(Sitecore.Data.Items.Item sitecoreItem)
        {
            if (sitecoreItem == null)
            {
                return "";
            }

            string iconImageRaw = ThemeManager.GetIconImage(sitecoreItem, 32, 32, "", "");

            if (!string.IsNullOrWhiteSpace(iconImageRaw) && iconImageRaw.Contains("src="))
            {
                int i0 = iconImageRaw.IndexOf("src=");
                int i1 = iconImageRaw.IndexOf('"', i0 + 1);
                if (i1 < 0)
                {
                    return null;
                }

                int i2 = iconImageRaw.IndexOf('"', i1 + 1);
                if (i2 < 0)
                {
                    return null;
                }

                return iconImageRaw.Substring(i1, i2 - i1).Trim(' ', '"', '\\');
            }

            return null;
        }
    }
}